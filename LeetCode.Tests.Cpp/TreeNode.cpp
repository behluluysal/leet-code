#include "pch.h"
#include "TreeNode.h"

// From level order vector
TreeNode* createBinaryTree(const std::vector<int>& values) {
	if (values.empty() || values[0] == -1) return nullptr;

	TreeNode* root = new TreeNode(values[0]);
	std::queue<TreeNode*> q;
	q.push(root);

	size_t i = 1;
	while (i < values.size()) {
		TreeNode* node = q.front();
		q.pop();

		if (values[i] != -1) {
			node->left = new TreeNode(values[i]);
			q.push(node->left);
		}
		i++;

		if (i < values.size() && values[i] != -1) {
			node->right = new TreeNode(values[i]);
			q.push(node->right);
		}
		i++;
	}

	return root;
}

// To level order vector
std::vector<int> binaryTreeToVector(TreeNode* root) {
	std::vector<int> result;
	if (!root) return result;

	std::queue<TreeNode*> q;
	q.push(root);

	while (!q.empty()) {
		TreeNode* node = q.front();
		q.pop();
		if (node) {
			result.push_back(node->val);
			q.push(node->left);
			q.push(node->right);
		}
		else {
			result.push_back(-1);
		}
	}

	return result;
}

void deleteBinaryTree(TreeNode* root) {
	if (!root) return;
	deleteBinaryTree(root->left);
	deleteBinaryTree(root->right);
	delete root;
}

int maxDepth(TreeNode* root) {
	if (!root) return 0;
	return 1 + std::max(maxDepth(root->left), maxDepth(root->right));
}

bool leafSimilar(TreeNode* root1, TreeNode* root2) {
	std::vector<int> endLeaves;
	std::vector<int> endLeaves2;
	collectLeafNodes(root1, endLeaves);
	collectLeafNodes(root2, endLeaves2);
	return endLeaves == endLeaves2;
}

int goodNodes(TreeNode* root, int maxValue) {
	if (!root) return 0;

	int count = (root->val >= maxValue) ? 1 : 0;
	maxValue = std::max(maxValue, root->val);

	return count + goodNodes(root->left, maxValue) + goodNodes(root->right, maxValue);
}

int pathSum(TreeNode* root, int targetSum) {
	if (!root) return 0;

	int count = countPaths(root, targetSum);

	count += pathSum(root->left, targetSum);
	count += pathSum(root->right, targetSum);

	return count;
}

int longestZigZag(TreeNode* root, int bypassPolicy) {
	if (!root) return 0;
	int count = 0;

	// bypassPolicy
	// if 1, only search left zigzag
	// if 2, only search right zigzag

	if (bypassPolicy == 1) {
		count = drawZigZag(root, true);
	}
	else if (bypassPolicy == 2) {
		count = drawZigZag(root, false);
	}
	else {
		count = std::max(drawZigZag(root, true), drawZigZag(root, false)); // happens only for root node
	}

	count = std::max(longestZigZag(root->left, 1), count);
	count = std::max(longestZigZag(root->right, 2), count);
	
	return count;
}

TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q) {
	if (!root || root == p || root == q) return root; // Base case

	TreeNode* leftLCA = lowestCommonAncestor(root->left, p, q);
	TreeNode* rightLCA = lowestCommonAncestor(root->right, p, q);

	if (leftLCA && rightLCA) return root;

	return leftLCA ? leftLCA : rightLCA;
}

std::vector<int> rightSideView(TreeNode* root) {
	std::vector<int>result;
	if (!root) return result;

	std::queue<TreeNode*>currentLevel;
	currentLevel.push(root);
	while (currentLevel.size() != 0) {
		result.push_back(currentLevel.back()->val);
		size_t size = currentLevel.size();
		for (size_t i = 0; i < size; i++) {
			TreeNode* node = currentLevel.front();
			currentLevel.pop();
			if (node->left) currentLevel.push(node->left);
			if (node->right) currentLevel.push(node->right);
		}
	}
	return result;
}

int maxLevelSum(TreeNode* root) {
	if (!root) return 0;

	std::queue<TreeNode*>currentLevel;
	currentLevel.push(root);
	int result = -100000;
	int resultLevel = 0;
	int level = 0;

	while (currentLevel.size() != 0) {
		size_t size = currentLevel.size();
		int sum = 0;
		level++;
		for (size_t i = 0; i < size; i++) {
			TreeNode* node = currentLevel.front();
			currentLevel.pop();
			sum += node->val;
			if (node->left) currentLevel.push(node->left);
			if (node->right) currentLevel.push(node->right);
		}
		if (sum > result) {
			resultLevel = level;
			result = sum;
		}
	}
	return resultLevel;
}

TreeNode* searchBST(TreeNode* root, int val) {
	return findNode(root, val);
}

TreeNode* deleteNode(TreeNode* root, int key) {
	if (!root) return nullptr;

	if (root->val == key) {
		TreeNode* nodeToDelete = root;
		if (!root->right) {
			root = root->left;  // Promote left child
			nodeToDelete = nullptr;
			delete nodeToDelete;
		}
		else {
			TreeNode* rightChild = root->right;
			TreeNode* leftmost = rightChild;
			while (leftmost->left) {
				leftmost = leftmost->left;
			}
			leftmost->left = root->left;
			root = rightChild;
			nodeToDelete = nullptr;
			delete nodeToDelete;
		}
		return root;
	}
	root->left = deleteNode(root->left, key);
	root->right = deleteNode(root->right, key);

	return root;
}

#pragma region RoadMap Questions

TreeNode* invertTree(TreeNode* root) {
	if (!root) return nullptr;

	TreeNode* temp = root->left;

	root->left = root->right;
	root->right = temp;

	invertTree(root->left);
	invertTree(root->right);
	return root;
}

int diameterOfBinaryTree(TreeNode* root) {
	int max = 0;
	diameterOfBinaryTreeDfs(root, max);
	return max;
}

int diameterOfBinaryTreeDfs(TreeNode* root, int& max) {
	if (!root) return 0;

	int left = diameterOfBinaryTreeDfs(root->left, max);
	int right = diameterOfBinaryTreeDfs(root->right, max);
	max = std::max(max, left + right);
	return 1 + std::max(left, right);
}

bool isBalanced(TreeNode* root) {
	bool balanced = true;
	isBalancedDfs(root, balanced);
	return balanced;
}

int isBalancedDfs(TreeNode* root, bool& balanced) {
	if (!root || !balanced) return 0;

	int leftHeight = isBalancedDfs(root->left, balanced);
	int rightHeight = isBalancedDfs(root->right, balanced);

	if (std::abs(leftHeight - rightHeight) > 1)
	{
		balanced = false;
	}
	return 1 + std::max(leftHeight, rightHeight);
}

bool isSameTree(TreeNode* p, TreeNode* q) {
	if (!p && !q) return true;
	if ((p && !q) || (!p && q)) return false;

	if (p->val == q->val)
		return (isSameTree(p->left, q->left) && isSameTree(p->right, q->right));
	else
		return false;
}

#pragma endregion


// Helper methods
std::vector<int> collectLeafNodes(TreeNode* head, std::vector<int>& endLeaves) {
	if (!head) return endLeaves;
	if (!head->left && !head->right) {
		endLeaves.push_back(head->val);
		return endLeaves;
	}
	collectLeafNodes(head->left, endLeaves);
	collectLeafNodes(head->right, endLeaves);
	return endLeaves;
}

int countPaths(TreeNode* head, long targetSum) {
	if (!head) return 0;

	int count = (head->val == targetSum) ? 1 : 0;

	count += countPaths(head->left, targetSum - head->val);
	count += countPaths(head->right, targetSum - head->val);

	return count;
}

int drawZigZag(TreeNode* root, bool toLeft) {
	if (!root) return 0;

	if (toLeft && root->left) {
		return 1 + drawZigZag(root->left, false);
	}
	else if (!toLeft && root->right) {
		return 1 + drawZigZag(root->right, true);
	}
	return 0;
}

TreeNode* findNode(TreeNode* root, int target) {
	if (!root) return nullptr;

	if (root->val == target) return root;

	TreeNode* leftResult = findNode(root->left, target);
	if (leftResult) return leftResult;

	return findNode(root->right, target);
}

std::queue<TreeNode*> getBelowLevelNodes(std::queue<TreeNode*> &currentLevel) {
	size_t size = currentLevel.size();
	for (size_t i = 0; i < size; i++) {
		TreeNode* node = currentLevel.front();
		currentLevel.pop();
		if(node->left) currentLevel.push(node->left);
		if(node->right) currentLevel.push(node->right);
	}
	return currentLevel;
}