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
int countPaths(TreeNode* head, int targetSum);

// Actual Methods
// https://leetcode.com/problems/maximum-depth-of-binary-tree
int maxDepth(TreeNode* root);

// https://leetcode.com/problems/leaf-similar-trees
bool leafSimilar(TreeNode* root1, TreeNode* root2);

// https://leetcode.com/problems/count-good-nodes-in-binary-tree
int goodNodes(TreeNode* root, int maxValue = -10001);

// https://leetcode.com/problems/path-sum-iii
int pathSum(TreeNode* root, int targetSum);

#endif // TREENODE_H
