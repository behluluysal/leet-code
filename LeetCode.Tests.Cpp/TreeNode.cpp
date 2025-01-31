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