#ifndef TREENODE_H
#define TREENODE_H

#include <vector>
#include <queue>

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

// Helper functions for testing
TreeNode* createBinaryTree(const std::vector<int>& values);
std::vector<int> binaryTreeToVector(TreeNode* root);
void deleteBinaryTree(TreeNode* root);
std::vector<int> collectLeafNodes(TreeNode* head, std::vector<int>& endLeaves);
int countPaths(TreeNode* head, long targetSum);
int drawZigZag(TreeNode* root, bool toLeft);
TreeNode* findNode(TreeNode* root, int target);
std::queue<TreeNode*> getBelowLevelNodes(std::queue<TreeNode*> &currentLevel);


// Actual Methods
// https://leetcode.com/problems/maximum-depth-of-binary-tree
int maxDepth(TreeNode* root);

// https://leetcode.com/problems/leaf-similar-trees
bool leafSimilar(TreeNode* root1, TreeNode* root2);

// https://leetcode.com/problems/count-good-nodes-in-binary-tree
int goodNodes(TreeNode* root, int maxValue = -10001);

// https://leetcode.com/problems/path-sum-iii
int pathSum(TreeNode* root, int targetSum);

// https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree
int longestZigZag(TreeNode* root, int bypassPolicy = 0);

// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q);

// https://leetcode.com/problems/binary-tree-right-side-view
std::vector<int> rightSideView(TreeNode* root);

// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree
int maxLevelSum(TreeNode* root);

// https://leetcode.com/problems/search-in-a-binary-search-tree
TreeNode* searchBST(TreeNode* root, int val);

// https://leetcode.com/problems/delete-node-in-a-bst/description
TreeNode* deleteNode(TreeNode* root, int key);

#endif // TREENODE_H
